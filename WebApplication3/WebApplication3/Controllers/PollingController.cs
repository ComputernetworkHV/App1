using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.DAL;
using WebApplication1.Models;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class PollingController : ApiController
    {
        private NotesContext db = new NotesContext();

        public static int PolledNoteId = -1;

        [ResponseType(typeof(Note))]
        public async Task<IHttpActionResult> GetNote()
        {
            int id = PolledNoteId;
            while (id == PolledNoteId)
            {
                Thread.Sleep(500);
            }
            id = PolledNoteId;
            
            Note note = await db.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }
    }
}
