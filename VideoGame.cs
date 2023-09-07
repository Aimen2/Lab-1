using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class VideoGame : IComparable<VideoGame>
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Publisher { get; set; }
    public int Year { get; set; }
    public double Rating { get; set; }

    public int CompareTo(VideoGame other)
    {
        return string.Compare(this.Title, other.Title, StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString()
    {
        return $"Title: {Title}, Genre: {Genre}, Publisher: {Publisher}, Year: {Year}, Rating: {Rating:F2}";
    }
}
