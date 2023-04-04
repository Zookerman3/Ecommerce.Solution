using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace EcommerceSite.Models
{

  public class ApiResponse<T>
  {
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    public bool Succeeded { get; set; }
    public List<string> Errors { get; set; }
    public string Message { get; set; }
    public List<T> Data { get; set; }
  }
}