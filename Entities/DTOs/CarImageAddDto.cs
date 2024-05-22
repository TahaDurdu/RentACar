using System;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs
{
	public class CarImageAddDto
	{
		public int CarId { get; set; }
		public IFormFile FormFile { get; set; }

	}
}

