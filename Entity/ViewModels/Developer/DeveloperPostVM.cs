using Entity.Concrete;
using Microsoft.AspNetCore.Http;

namespace Entity.ViewModels.Developer
{
    public class DeveloperPostVM
    {
        public string? Position { get; set; }
        public List<Concrete.Project>? Projects { get; set; }
        public string AppUserId { get; set; }
        public IFormFile? FormFile { get; set; }
        public Concrete.AppUser AppUser { get; set; }


    }
}
