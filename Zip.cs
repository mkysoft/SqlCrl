using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SqlCrl
{
    public static class Zip
    {

		[SqlFunction]
		public static System.Data.SqlTypes.SqlBytes Unzip(System.Data.SqlTypes.SqlBytes input)
		{
			// Open an existing zip file for reading
			ZipStorer zip = ZipStorer.Open(input.Stream, FileAccess.Read);

			// Read the central directory collection
			List<ZipStorer.ZipFileEntry> dir = zip.ReadCentralDir();

			System.Data.SqlTypes.SqlBytes sqlBytes = new System.Data.SqlTypes.SqlBytes();

			// Look for the desired file
			foreach (ZipStorer.ZipFileEntry entry in dir)
			{
				// File found, extract it
				var unzippedStream = new MemoryStream();
				zip.ExtractFile(entry, unzippedStream);
				sqlBytes = new System.Data.SqlTypes.SqlBytes(unzippedStream);
				break;
			}
			zip.Close();
			return sqlBytes;
		}

	}
}
