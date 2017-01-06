using Cloud_Harry.DataObjects;
using Cloud_Harry.Models;
using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;

namespace Cloud_Harry.Controllers
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
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        public Task DeleteLocation(string id)
        {
            return DeleteAsync(id);
        }
    }
}
