﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
	//https://localhost:portnumber/api/students
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		//GET:https://localhost:portnumber/api/students
		[HttpGet]
		public IActionResult GetAllStudent()
		{
			string[] studentNames = new string[] { "John", "Priya", "pallavi", "vivan", "sngram" };
			return Ok(studentNames);
		}
	}
}