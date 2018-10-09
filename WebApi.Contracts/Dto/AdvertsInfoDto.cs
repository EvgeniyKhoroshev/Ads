using System.Collections.Generic;

namespace Ads.Contracts.Dto
{
    public class AdvertsInfoDto
    {
        public int Id { get; set; }
        public IList<AdvertType> Types { get; set; }
        public IList<Category> Categories { get; set; }
        public IList<City> Cities { get; set; }
        public IList<Status> Statuses { get; set; }
        public IList<Region> Regions { get; set; }
        public string FindCityById(int id)
        {
            foreach(var s in Cities)
            {
                if (s.Id == id)
                    return s.Name;
            }
            return "err";
        }
    }
}
