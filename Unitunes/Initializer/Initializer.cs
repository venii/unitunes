using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Unitunes.Models;
using Unitunes.Models.Servicos;

namespace Unitunes.Initializer
{

    public class Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<dbEntities>
    {
        protected override void Seed(dbEntities context)
        {
            SqlConnection.ClearAllPools();

            var academico = new List<Unitunes.Models.Academico>
            {
                new Administrador{Id = 1,Email ="admin",Password="1234",PrimeiroNome="Administrator",SegundoNome="",ContaAcademico =new ContaAcademico{Id = 1 , Credito = 0 , Ativo = true} },
            };

           /* var medias = new List<Media>
            {
                new Media{Author = academics.Single(x=>x.Login=="felipe"),CreatedOn=DateTime.Now,Description="Senhor dos Anéis",File= null,Length=150,MediaType=MediaType.Book,Name="Senhor dos Anéis",Price=5 },
                   };
            */
            academico.ForEach(s => context.AcademicoSet.Add(s));
           
            context.SaveChanges();
        }
    }
}