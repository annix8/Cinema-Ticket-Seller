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
        public async Task<ActionResult> RenderImage(int id)
        {
            Image image =  this._imageService.GetImage(id);

            byte[] photoBack = image.ImageData;

            return File(photoBack, "image/png");
        }
    }
}