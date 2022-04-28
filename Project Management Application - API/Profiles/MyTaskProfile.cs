using MySolution.Model;
using AutoMapper;
using Project_Management_Application___API.Helpers;

namespace Project_Management_Application___API.Profiles
{
    public class MyTaskProfile:Profile
    {
        public MyTaskProfile()
        {
            CreateMap<MyTask, Models.MyTaskForUpdateDto>();
            CreateMap<Models.MyTaskForUpdateDto, MyTask>();
        }
    }
}