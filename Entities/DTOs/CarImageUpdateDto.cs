using System;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs
{
	public class CarImageUpdateDto
	{
		public int Id { get; set; }
		public IFormFile FormFile { get; set; }

	}
}

