using Microsoft.EntityFrameworkCore;
using Pies.API.DbContexts;
using Pies.API.Entities;
using Pies.API.Helpers;
using Pies.API.Models;
using Pies.API.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pies.API.Services
{
    public class PiesRepository : IPiesRepository, IDisposable
    {
        private readonly PiesContext _context;
        private readonly IPropertyMappingService _propertyMappingService;

        public PiesRepository(PiesContext context,
            IPropertyMappingService propertyMappingService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _propertyMappingService = propertyMappingService ??
                throw new ArgumentNullException(nameof(propertyMappingService));
        }

        public void AddPie(Pie pie)
        {
            if (pie == null)
            {
                throw new ArgumentNullException(nameof(pie));
            }

            pie.Id = Guid.NewGuid();

            foreach (var pieReview in pie.PieReviews)
            {
                pieReview.Id = Guid.NewGuid();
            }

            _context.Pies.Add(pie); 
        }         

        public void DeletePie(Pie pie)
        {
            _context.Pies.Remove(pie);
        }
  
        public Pie GetPie(Guid pieId)
        {
            if (pieId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(pieId));
            }

            return _context.Pies
              .Where(c => c.Id == pieId).FirstOrDefault();
        }

        public IEnumerable<Pie> GetPies()
        {
            return _context.Pies.ToList();
        }

        // get pies and filter by query string and/or search by searchString
        public PagedList<Pie> GetPies(DefaultResourceParameters piesResourceParameters)
        {
            if (piesResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(piesResourceParameters));
            }

            var collection = _context.Pies as IQueryable<Pie>;

            if (!string.IsNullOrWhiteSpace(piesResourceParameters.Name))
            {
                var name = piesResourceParameters.Name.Trim();
                collection = collection.Where(a => a.Name == name);
            }

            if (!string.IsNullOrWhiteSpace(piesResourceParameters.SearchQuery))
            {
                var searchQuery = piesResourceParameters.SearchQuery.Trim();
                collection = collection.Where(a => a.Name.Contains(searchQuery));
            }

            if (!string.IsNullOrWhiteSpace(piesResourceParameters.OrderBy))
            {
                // get property mapping dictionary
                var piePropertyMappingDictionary =
                    _propertyMappingService.GetPropertyMapping<PieDto, Pie>();
                collection = collection.ApplySort(piesResourceParameters.OrderBy, piePropertyMappingDictionary);
            }

             return PagedList<Pie>.Create(collection,
                piesResourceParameters.PageNumber,
                piesResourceParameters.PageSize);
        }

        public IEnumerable<Pie> GetPies(IEnumerable<Guid> pieIds)
        {
            if (pieIds == null)
            {
                throw new ArgumentNullException(nameof(pieIds));
            }

            return _context.Pies.Where(a => pieIds.Contains(a.Id))
                .OrderBy(a => a.Name)
                .ToList();
        }

        public void UpdatePie(Pie pie)
        {
            // no code in this implementation
        }

        public void AddPieType(PieType pieType)
        {
            if (pieType == null)
            {
                throw new ArgumentNullException(nameof(pieType));
            }

            // the repository fills the id (instead of using identity columns)
            pieType.Id = Guid.NewGuid();

            _context.PieTypes.Add(pieType);
        }

        public bool PieExists(Guid pieId)
        {
            if (pieId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(pieId));
            }

            return _context.Pies.Any(a => a.Id == pieId);
        }

        public void DeletePieType(PieType pieType)
        {
            if (pieType == null)
            {
                throw new ArgumentNullException(nameof(pieType));
            }

            _context.PieTypes.Remove(pieType);
        }
        
        public PieType GetPieType(Guid pieTypeId)
        {
            if (pieTypeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(pieTypeId));
            }

            return _context.PieTypes.FirstOrDefault(a => a.Id == pieTypeId);
        }

        public IEnumerable<PieType> GetPieTypes()
        {
            return _context.PieTypes.ToList<PieType>();
        }
         
        public IEnumerable<PieType> GetPieTypes(IEnumerable<Guid> pieTypeIds)
        {
            if (pieTypeIds == null)
            {
                throw new ArgumentNullException(nameof(pieTypeIds));
            }

            return _context.PieTypes.Where(a => pieTypeIds.Contains(a.Id))
                .OrderBy(a => a.Name)
                .ToList();
        }

        public void UpdatePieType(PieType pieType)
        {
            // no code in this implementation
        }

        public IEnumerable<PieReview> GetPieReviews(Guid pieId)
        {
            if (pieId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(pieId));
            }

            return _context.PieReviews
                        .Where(c => c.PieId == pieId)
                        .OrderBy(c => c.DateCreated).ToList();
        }

        public PieReview GetPieReview(Guid pieId, Guid pieReviewId)
        {
            if (pieId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(pieId));
            }

            if (pieReviewId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(pieReviewId));
            }

            return _context.PieReviews
              .Where(c => c.Id == pieReviewId && c.PieId == pieId).FirstOrDefault();
        }

        public void AddPieReview(Guid pieId, PieReview pieReview)
        {
            if (pieId == null)
            {
                throw new ArgumentNullException(nameof(pieId));
            }

            if (pieReview == null)
            {
                throw new ArgumentNullException(nameof(pieReview));
            }

            // set the pieId to the passed in pie Id
            pieReview.PieId = pieId;
            _context.PieReviews.Add(pieReview);
        }

        public void UpdatePieReview(PieReview pieReview)
        {
            // no code in this implementation
            // save method in controller already implements the changes
        }

        public void DeletePieReview(PieReview pieReview)
        {
            _context.PieReviews.Remove(pieReview);
        }

        public IEnumerable<Shop> GetShops()
        {
            return _context.Shops.ToList();
        }

        public PagedList<Shop> GetShops(ShopResourceParameters shopResourceParameters)
        {
            if (shopResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(shopResourceParameters));
            }

            var collection =   _context.Shops.Include(s => s.Location)
                                             .Where(s => s.Location.Latitude > shopResourceParameters.SouthWestLat &&
                                                         s.Location.Latitude < shopResourceParameters.NorthEastLat &&
                                                         s.Location.Longitude > shopResourceParameters.SouthWestLng &&
                                                         s.Location.Longitude < shopResourceParameters.NorthEastLng);

            if (!string.IsNullOrWhiteSpace(shopResourceParameters.Name))
            {
                var name = shopResourceParameters.Name.Trim();
                collection = collection.Where(a => a.Name == name);
            }

            if (!string.IsNullOrWhiteSpace(shopResourceParameters.SearchQuery))
            {
                var searchQuery = shopResourceParameters.SearchQuery.Trim();
                collection = collection.Where(a => a.Name.Contains(searchQuery));
            }

            if (!string.IsNullOrWhiteSpace(shopResourceParameters.OrderBy))
            {
                // get property mapping dictionary
                var piePropertyMappingDictionary =
                    _propertyMappingService.GetPropertyMapping<ShopDto, Shop>();
                collection = collection.ApplySort(shopResourceParameters.OrderBy, piePropertyMappingDictionary);
            }

            return PagedList<Shop>.Create(collection,
                shopResourceParameters.PageNumber,
                shopResourceParameters.PageSize);
        }

        public Shop GetShop(Guid shopId)
        {
            if (shopId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(shopId));
            }

            return _context.Shops
              .Where(c => c.Id == shopId).FirstOrDefault();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
               // dispose resources when needed
            }
        }

        
    }
}
