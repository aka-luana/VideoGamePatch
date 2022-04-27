using System;

namespace VideoGamePatch.Entity
{
    public partial class VideoGame
    {
        public virtual int Id { get; set; }

        public virtual string Title { get; set; }

        public virtual string Publisher { get; set; }

        public virtual DateTime? ReleaseDate { get; set; }

        public VideoGame(int id, string title, string publisher, DateTime? releaseDate)
        {
            Id = id;
            Title = title;
            Publisher = publisher;
            ReleaseDate = releaseDate;
        }
    }
}
