using AutoMapper;
using Entity.Concrete;
using Entity.ViewModels.About;
using Entity.ViewModels.ChooseUs;
using Entity.ViewModels.Comment;
using Entity.ViewModels.Contact;
using Entity.ViewModels.Developer;
using Entity.ViewModels.Project;
using Entity.ViewModels.Quote;
using Entity.ViewModels.Services;
using Entity.ViewModels.Setting;
using Entity.ViewModels.Slider;
using Entity.ViewModels.Statistic;

namespace Business.Utilities.Profiles;

public class Mapper:Profile
{
	public Mapper()
	{
		CreateMap<SliderPostVM, Slider>();
		CreateMap<Slider, SliderGetVM>();
		CreateMap<Statistic, StatisticGetVM>();
		CreateMap<About, AboutGetVM>();
		CreateMap<ChooseUs, ChooseUsGetVM>();
		CreateMap<ChooseUsGetVM, ChooseUsPostVM>();
		CreateMap<Service, ServicesGetVM>();
		CreateMap<DeveloperPostVM, Developer>();
		CreateMap<DeveloperGetVM, DeveloperPostVM>();
		CreateMap<Developer, DeveloperPostVM>();
		CreateMap<Developer, DeveloperGetVM>();
		CreateMap<Project, ProjectGetVM>();
		CreateMap<ProjectPostVM, Project>().ReverseMap();
		CreateMap<Comment, CommentGetVM>();
		CreateMap<QuotePostVM, Quote>();
		CreateMap<Quote, QuoteGetVM>();
		CreateMap<QuoteGetVM, QuotePostVM>();
		CreateMap<CommentPostVM, Comment>();
		CreateMap<ContactPostVM, Contact>();
		CreateMap<Contact, ContactGetVM>();
		CreateMap<Setting, SettingGetVM>();
		CreateMap<ServicesGetVM, ServicesPostVM>();



	}
}
