using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VideoGamePatch.Entity;

namespace VideoGamePatch.Controllers
{
    [Route("api/video-game")]
    public class VideoGameController : Controller
    {
        IList<VideoGame> VideoGames { get; set; }

        public VideoGameController()
        {
            VideoGames = new List<VideoGame>();

            VideoGames.Add(new VideoGame(1, "Call of Duty: Warzone", "Activision", new System.DateTime(2020, 3, 10)));
            VideoGames.Add(new VideoGame(2, "Friday the 13th: The Game", "Gun Media", new System.DateTime(2017, 5, 26)));
            VideoGames.Add(new VideoGame(3, "DOOM Eternal", "Bethesda", new System.DateTime(2020, 3, 20)));
        }

        //use this layout for update object (exemple replacing only game title):
        //    [
        //        {
        //            "value": "Friday the 13th",
        //            "path": "/title",
        //            "op": "replace"
        //        }
        //    ]
        [HttpPatch("{id:int}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<VideoGame> patchEntity)
        {
            var entity = VideoGames.FirstOrDefault(videoGame => videoGame.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            patchEntity.ApplyTo(entity, ModelState);

            return Ok(entity);
        }
    }
}
