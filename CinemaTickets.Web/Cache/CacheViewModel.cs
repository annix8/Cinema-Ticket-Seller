using CinemaTickets.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTickets.Web.Cache
{
    public static class CacheViewModel
    {
        public static SeatViewModel svm;

        public static void CacheModel(SeatViewModel model)
        {
            svm = model;
        }
    }
}