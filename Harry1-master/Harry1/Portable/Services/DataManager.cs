using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Portable.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Common;

namespace Portable
{
    public class DataManager
    {
        private readonly MobileServiceClient _client;

        private readonly IMobileServiceSyncTable<Model.Location> _locationTable;
        public static DataManager DefaultManager { get; private set; } = new DataManager();

        public MobileServiceClient CurrentClient
        {
            get { return _client; }
        }

        public DataManager()
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;
            try
            {
                _client = new MobileServiceClient(Constants.ApplicationUrl);

                var store = new MobileServiceSQLiteStore("localstore.db");
                store.DefineTable<Model.Location>();

                _client.SyncContext.InitializeAsync(store);

                _locationTable = _client.GetSyncTable<Model.Location>();

                _locationTable.PullAsync(null, _locationTable.CreateQuery());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public async Task<ObservableCollection<Model.Location>> GetLocationsAsync(bool syncItems = false)
        {
            try
            {

                if (syncItems)
                {
                    await SyncAsync();
                }

                IEnumerable<Model.Location> locations = await _locationTable.ToEnumerableAsync();

                return new ObservableCollection<Model.Location>(locations);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Get Error: {0}", ex.Message);
                throw;

            }
        }

        private async Task SyncAsync()
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;
            try
            {
                await _client.SyncContext.PushAsync();
                await _locationTable.PullAsync("allLocations", _locationTable.CreateQuery());
            }
            catch (MobileServicePushFailedException exc)
            {
                if (exc.PushResult != null)
                {
                    syncErrors = exc.PushResult.Errors;
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            if (syncErrors != null)
            {
                foreach (var error in syncErrors)
                {
                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                    {
                        await error.CancelAndUpdateItemAsync(error.Result);
                    }
                    else
                    {
                        await error.CancelAndDiscardItemAsync();
                    }

                    Debug.WriteLine(@"Error executing sync opertation. Item: {0} ({1}). Operation discarded.", error.TableName, error.Item["id"]);
                }
            }
        }
        public async Task SaveLocationAsync(Model.Location item)
        {
            try
            {
                if (item.Id == null)
                {
                    await _locationTable.InsertAsync(item);
                }
                else
                {
                    await _locationTable.UpdateAsync(item);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Save Error: {0}", ex.Message);
                throw;
            }
        }
    }
}  

