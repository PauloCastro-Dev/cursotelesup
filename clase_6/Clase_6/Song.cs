using System;

namespace Clase_6;

public class Song
{
	public string Album { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public string Genre { get; set; }
	public Song(string album, string title, string description, string genre)
	{
		Album = album;
		Title = title;
		Description = description;
		Genre = genre;
	}
}
