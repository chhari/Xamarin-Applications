using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using ContentCollector.Azure.DataObjects;
using ContentCollector.Azure.Models;
using Microsoft.Azure.Mobile.Server;

namespace ContentCollector.Azure.Controllers
{
    public class LocationController : TableController<Location>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Location>(context, Request);
        }

        public IQueryable<Location> GetAllLocations()
        {
            return Query();
        }

        public SingleResult<Location> GetLocation(string id)
        {
            return Lookup(id);
        }

        public Task<Location> PatchLocation(string id, Delta<Location> patch)
        {
            return UpdateAsync(id, patch);
        }

        public async Task<IHttpActionResult> PostLocation(Location item)
        {
            Location current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new {id = current.Id}, current);
        }

        public Task DeleteLocation(string id)
        {
            return DeleteAsync(id);
        }
    }
}
