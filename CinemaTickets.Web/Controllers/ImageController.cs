using CinemaTickets.DataModel.Models;
using CinemaTickets.Services;
using CinemaTickets.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CinemaTickets.Web.Controllers
{
    public class ImageController : Controller
    {
        private IImageService _imageService;
        public ImageController()
        {
            this._imageService = new ImageService();
        }
        // GET: Image
        public ActionResult RenderImage(int id)
        {
            Image image =  this._imageService.GetImage(id);

            byte[] imageInBinary = image.ImageData;

            return File(imageInBinary, "image/png");
        }
    }
}