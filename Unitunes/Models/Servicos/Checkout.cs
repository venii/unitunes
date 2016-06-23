using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unitunes.Models.Abstratos;

namespace Unitunes.Models.Servicos
{
    public static class Checkout
    {
        public static void addMedia(int id)
        {
            if (HttpContext.Current.Session["medias_selecionadas"] == null)
                HttpContext.Current.Session["medias_selecionadas"] = new List<int>();

            var lista = (List<int>)HttpContext.Current.Session["medias_selecionadas"];
            lista.Add(id);
        }

        public static void removeMedia(int id)
        {
            if (HttpContext.Current.Session["medias_selecionadas"] == null)
                HttpContext.Current.Session["medias_selecionadas"] = new List<int>();

            var lista = (List<int>)HttpContext.Current.Session["medias_selecionadas"];
            lista.Remove(id);
        }

        public static List<int> getMedias()
        {
            if (HttpContext.Current.Session["medias_selecionadas"] == null)
                HttpContext.Current.Session["medias_selecionadas"] = new List<int>();

            return (List<int>)HttpContext.Current.Session["medias_selecionadas"];
        }
    }
}