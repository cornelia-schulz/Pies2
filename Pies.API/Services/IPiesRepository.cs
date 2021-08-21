using Pies.API.Entities;
using Pies.API.ResourceParameters;
using System;
using System.Collections.Generic;

namespace Pies.API.Services
{
    public interface IPiesRepository
    {    
        IEnumerable<Pie> GetPies();
        IEnumerable<Pie> GetPies(PiesResourceParameters piesResourceParameters);
        IEnumerable<Pie> GetPies(IEnumerable<Guid> pieIds);
        Pie GetPie(Guid pieId);
        void AddPie(Pie pie);
        void UpdatePie(Pie pie);
        void DeletePie(Pie pie);
        IEnumerable<PieType> GetPieTypes();
        PieType GetPieType(Guid pieTypeId);
        IEnumerable<PieType> GetPieTypes(IEnumerable<Guid> pieTypeIds);
        void AddPieType(PieType PieType);
        void DeletePieType(PieType PieType);
        void UpdatePieType(PieType PieType);
        bool PieExists(Guid pieTypeId);
        IEnumerable<PieReview> GetPieReviews(Guid pieId);
        PieReview GetPieReview(Guid pieId, Guid pieReviewId);
        void AddPieReview(Guid pieId, PieReview pieReview);
        void UpdatePieReview(PieReview pieReview);
        void DeletePieReview(PieReview pieReview);
        bool Save();
    }
}
