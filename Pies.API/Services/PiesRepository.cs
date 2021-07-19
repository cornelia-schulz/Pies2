using Pies.API.DbContexts;
using Pies.API.Entities; 
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
            // always set the AuthorId to the passed-in authorId
            pie.PieTypeId = pieTypeId;
            _context.Pies.Add(pie); 
        }         

        public void DeletePie(Pie pie)
        {
            _context.Pies.Remove(pie);
        }
  
        public Pie GetPie(Guid pieTypeId, Guid pieId)
        {
            if (pieTypeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(pieTypeId));
            }

            if (pieId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(pieId));
            }

            return _context.Pies
              .Where(c => c.PieTypeId == pieTypeId && c.Id == pieId).FirstOrDefault();
        }

        public IEnumerable<Pie> GetPies(Guid pieTypeId)
        {
            if (pieTypeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(pieTypeId));
            }

            return _context.Pies
                        .Where(c => c.PieTypeId == pieTypeId)
                        .OrderBy(c => c.Name).ToList();
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

        public bool PieTypeExists(Guid pieTypeId)
        {
            if (pieTypeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(pieTypeId));
            }

            return _context.PieTypes.Any(a => a.Id == pieTypeId);
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
