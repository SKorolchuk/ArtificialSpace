using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace ASpace
{
	public class Resources
	{
		internal Dictionary<string, Texture2D> Textures { get; set; }

		internal Dictionary<string, SpriteFont> Fonts { get; set; }

		internal Dictionary<string, Song> Music { get; set; }

		internal List<string> MusicNames { get; set; }

		internal Dictionary<string, SoundEffect> Sounds { get; set; }

		internal Dictionary<string, Texture2D> Effects { get; set; }

		public Resources()
		{
			Textures = new Dictionary<string, Texture2D>();
			Fonts = new Dictionary<string, SpriteFont>();
			Music = new Dictionary<string, Song>();
			MusicNames = new List<string>();
			Sounds = new Dictionary<string, SoundEffect>();
			Effects = new Dictionary<string, Texture2D>();
		}
	}
}
