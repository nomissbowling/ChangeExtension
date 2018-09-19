using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using OpenCvSharp.Extensions;
using OpenCvSharp.Utilities;
using OpenCvSharp.Blob;
using OpenCvSharp.UserInterface;

namespace ChangeExtension {
	class ChangeExtension {
		private string InputFolderPath = @"C:\Okabe\I5\Dataset\Forest";
		private string OutputFolderPath= @"C:\Okabe\I5\Dataset\ManualTrimming\Forest_png";
		private List<string> ImagePath;
		private List<string> InputExtension = new List<string>() { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };
		private string OutputExtension = ".png";

		public ChangeExtension() { this.Initialize(); }
		

		private void Initialize() {
			this.ImagePath = new List<string>();
			foreach(var e in this.InputExtension) this.ImagePath.AddRange(new List<string>(Directory.GetFiles(this.InputFolderPath, "*" + e)));
		}

		public void Do() {
			for(int i = 0; i < this.ImagePath.Count; ++i) {
				var mat = new Mat(this.ImagePath[i]);
				mat.ImWrite(this.OutputFolderPath+@"\"+i+this.OutputExtension);
			}
		}
	}
}
