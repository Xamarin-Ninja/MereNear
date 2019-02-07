using System.Collections.Generic;

namespace MereNear.Model
{
    public class UserModel
    {
        public int ID { get; set; }
        public string MobileNumber { get; set; }
        public string ProfilePicture { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string TotalExperience { get; set; }
        public List<ShowCaseImage> ShowcaseImagesList { get; set; }
    }

    public class ShowCaseImage
    {
        public string ShowcaseImages { get; set; }
    }
}
