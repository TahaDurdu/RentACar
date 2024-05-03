using System;
using Microsoft.AspNetCore.Http;

namespace Core.Helpers.FileHalper
{
	public interface IFileHelper
	{
        string Upload(IFormFile file, string root);
        void Delete(string filePath);
        string Update(IFormFile file, string filePath, string root);
    }
}

