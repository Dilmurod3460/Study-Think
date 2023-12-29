using AutoMapper;
using StudyThink.Domain.Entities.Admins;
using StudyThink.Domain.Entities.Callaborators;
using StudyThink.Domain.Entities.Categories;
using StudyThink.Domain.Entities.Course;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Domain.Entities.Payments;
using StudyThink.Domain.Entities.Students;
using StudyThink.Domain.Entities.Teachers;
using StudyThink.Domain.Entities.Videos;
using StudyThink.Service.DTOs.Admin;
using StudyThink.Service.DTOs.Callaborators;
using StudyThink.Service.DTOs.CallaboratorsDTO;
using StudyThink.Service.DTOs.Category;
using StudyThink.Service.DTOs.Courses.Course;
using StudyThink.Service.DTOs.Courses.CourseComment;
using StudyThink.Service.DTOs.Courses.CourseModel;
using StudyThink.Service.DTOs.Courses.CourseRequirment;
using StudyThink.Service.DTOs.Payment;
using StudyThink.Service.DTOs.Student;
using StudyThink.Service.DTOs.Teachers;
using StudyThink.Service.DTOs.Video;

namespace StudyThink.Api.Configurations;

public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        // Admin 
        CreateMap<AdminCreationDto, Admin>().ReverseMap();
        CreateMap<AdminUpdateDto, Admin>().ReverseMap();

        //Course
        CreateMap<CourseCreationDto, Course>().ReverseMap();
        CreateMap<CourseUpdateDto, Course>().ReverseMap();

        // CourseComment
        CreateMap<CourseCommentCreationDto, CourseComment>().ReverseMap();
        CreateMap<CourseCommentUpdateDto, CourseComment>().ReverseMap();


        // CourseModul
        CreateMap<CourseModulCreationDto, CourseModul>().ReverseMap();
        CreateMap<CourseModulUpdateDto, CourseModul>().ReverseMap();

        // CourseRequirment
        CreateMap<CourseReqCretionDto, CourseRequirment>().ReverseMap();
        CreateMap<CourseReqUpdateDto, CourseRequirment>().ReverseMap();

        // Category
        CreateMap<CategoryCreationDto, Category>().ReverseMap();
        CreateMap<CategoryUpdateDto, Category>().ReverseMap();

        // Callaborator
        CreateMap<CallaboratorsCreationDto, Callaborator>().ReverseMap();
        CreateMap<CallaboratorsUpdateDto, Callaborator>().ReverseMap();

        // Payment
        CreateMap<PaymentCreationDto, Payment>().ReverseMap();
        CreateMap<PaymentUpdateDto, Payment>().ReverseMap();

        // PaymentDetail
        CreateMap<PaymentDetailsCretionDto, PaymentDetails>().ReverseMap();
        CreateMap<PaymentDetailsUpdateDto, PaymentDetails>().ReverseMap();

        // Student
        CreateMap<StudentCreationDto, Student>().ReverseMap();
        CreateMap<StudentUpdateDto, Student>().ReverseMap();

        // Teacher
        CreateMap<TeacherCreationDto, Teacher>().ReverseMap();
        CreateMap<TeacherUpdateDto, Teacher>().ReverseMap();

        // Video
        CreateMap<VideoCreationDto, Video>().ReverseMap();
        CreateMap<VideoUpdateDto, Video>().ReverseMap();
    }
}
