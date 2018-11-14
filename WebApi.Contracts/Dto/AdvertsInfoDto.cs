using System.Collections.Generic;
using System.Linq;

namespace Ads.CoreService.Contracts.Dto
{
    public class AdvertsInfoDto
    {
        public int Id { get; set; }
        public IList<AdvertTypeDto> Types { get; set; }
        public IList<CategoryDto> Categories { get; set; }
        public IList<CityDto> Cities { get; set; }
        public IList<StatusDto> Statuses { get; set; }
        public IList<RegionDto> Regions { get; set; }
        public List<CategoryDto> GetCategoryLevel(int? level)
        {
            List<CategoryDto> result = new List<CategoryDto>();
            foreach (var s in Categories)
                if (s.ParentCategoryId == level)
                    result.Add(s);
            return result;
        }
        public bool isLowestLevel(int category_id)
        {
            if (Categories.FirstOrDefault(t => t.ParentCategoryId == category_id) == null)
                return true;
            return false;
        }
        public string FindCityById(int id)
        {
            foreach (var s in Cities)
            {
                if (s.Id == id)
                    return s.Name;
            }
            return "err";
        }
        public string FindStatusById(int id)
        {
            foreach (var s in Statuses)
            {
                if (s.Id == id)
                    return s.Name;
            }
            return "err";
        }
        public string FindCategoryById(int id)
        {
            foreach (var s in Categories)
            {
                if (s.Id == id)
                    return s.Name;
            }
            return "err";
        }
        public string FindRegionById(int id)
        {
            foreach (var s in Regions)
            {
                if (s.Id == id)
                    return s.Name;
            }
            return "err";
        }
        public string FindTypeById(int id)
        {
            foreach (var s in Types)
            {
                if (s.Id == id)
                    return s.Type;
            }
            return "err";
        }

    }
}
