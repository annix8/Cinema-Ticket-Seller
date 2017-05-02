using CinemaTickets.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Services.Services
{
    public interface IImageService
    {
        Image GetImage(int id);
        void AddImage(Image image);
    }
}
