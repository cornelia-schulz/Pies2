using Pies.API.DbContexts;
using Pies.API.Entities;
using Pies.API.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pies.API.Services
{
    public class PiesRepository : IPiesRepository, IDisposable
    {
        private readonly PiesContext _context;

        public PiesRepository(PiesContext context )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddPie(Guid pieTypeId, Pie pie)
        {
            if (pieTypeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(pieTypeId));
            }

            if (pie == null)
            {
                throw new ArgumentNullException(nameof(pie));
            }
            // always set the PieTypeId to the passed-in pieTypeId
            pie.PieTypeId = pieTypeId;
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
            return _context.Pies.ToList<Pie>();
        }

        // get pies and filter by query string and/or search by searchString
        public IEnumerable<Pie> GetPies(PiesResourceParameters piesResourceParameters)
        {
            if (piesResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(piesResourceParameters));
            }

            // if no query string or search string have been passed, return the full list of pies
            if (string.IsNullOrWhiteSpace(piesResourceParameters.Name)
                && string.IsNullOrWhiteSpace(piesResourceParameters.SearchQuery))
            {
                return GetPies();
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

            return collection.ToList();
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

            //foreach (var pie in author.Courses)
            //{
            //    course.Id = Guid.NewGuid();
            //}

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
