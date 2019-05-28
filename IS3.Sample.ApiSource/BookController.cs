using IS3.Sample.DataAccess;
using IS3.Sample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
//using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Net.Http.Formatting;
using Thinktecture.IdentityModel.WebApi;
using System.Security.Claims;

namespace IS3.Sample.ApiSource
{
    public class BookController:ApiController
    {
        [AllowAnonymous]
        public HttpResponseMessage Get()
        {
            var ctx = Request.GetOwinContext();
            //var bookService = Request.GetOwinContext().Get<IBookStroreService>("AspNet.Identity.Owin:"+typeof(IBookStroreService).AssemblyQualifiedName);//if don't use Microsoft.AspNet.Identity.Owin need assign the key
            var bookService = Request.GetOwinContext().Get<IBookStroreService>();
            Book book = bookService.GetAllBooks().First();
            return Request.CreateResponse(HttpStatusCode.OK ,new { name= book.Name,price = book.Price,method="get"});
        }

        //validate resource/action: access Thinktecture.IdentityModel.Owin.ResourceAuthorization.WebApi
        [ResourceAuthorize("AllBooks","Book")]
        public HttpResponseMessage Post()
        {
            var u = this.User as ClaimsPrincipal;
            var ctx = Request.GetOwinContext();
            //var bookService = Request.GetOwinContext().Get<IBookStroreService>("AspNet.Identity.Owin:"+typeof(IBookStroreService).AssemblyQualifiedName);//if don't use Microsoft.AspNet.Identity.Owin need assign the key
            var bookService = Request.GetOwinContext().Get<IBookStroreService>();
            Book book = bookService.GetAllBooks().First();
            //return Request.CreateResponse(HttpStatusCode.Accepted, new { name = book.Name, price = book.Price ,method="post"});            
            return Request.CreateResponse(new { name = book.Name, price = book.Price ,method="post",userName = u.Identity.Name,userRole=u.Claims.First()});
        }

        //validate resource/action: access Thinktecture.IdentityModel.Owin.ResourceAuthorization.WebApi
        [ResourceAuthorize("BookID", "Book")]
        public HttpResponseMessage PostAllBooks(string bookId)
        {
            var ctx = Request.GetOwinContext();
            //var bookService = Request.GetOwinContext().Get<IBookStroreService>("AspNet.Identity.Owin:"+typeof(IBookStroreService).AssemblyQualifiedName);//if don't use Microsoft.AspNet.Identity.Owin need assign the key
            var bookService = Request.GetOwinContext().Get<IBookStroreService>();
            Book book = bookService.GetAllBooks().First();
            //return Request.CreateResponse(HttpStatusCode.Accepted, new { name = book.Name, price = book.Price ,method="post"});            
            return Request.CreateResponse(new { name = book.Name, price = book.Price, method = "post" });
        }

        //validate resource/action: access Thinktecture.IdentityModel.Owin.ResourceAuthorization.WebApi
        [ResourceAuthorize("BookID", "Book")]
        public HttpResponseMessage GetBookId(string bookId)
        {
            var ctx = Request.GetOwinContext();
            //var bookService = Request.GetOwinContext().Get<IBookStroreService>("AspNet.Identity.Owin:"+typeof(IBookStroreService).AssemblyQualifiedName);//if don't use Microsoft.AspNet.Identity.Owin need assign the key
            var bookService = Request.GetOwinContext().Get<IBookStroreService>();
            Book book = bookService.GetAllBooks().First();
            //return Request.CreateResponse(HttpStatusCode.Accepted, new { name = book.Name, price = book.Price ,method="post"});            
            return Request.CreateResponse(new { name = book.Name, price = book.Price, method = "post" });
        }
    }
}
