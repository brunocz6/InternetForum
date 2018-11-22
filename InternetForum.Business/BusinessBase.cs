using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InternetForum.Business.Infrastructure;
using InternetForum.DL;
using InternetForum.Business.Interfaces;

namespace InternetForum.Business
{
	public class BusinessBase : IBusinessBase
	{
		protected readonly IUnitOfWork unitOfWork;
		private static bool isAutoMapperInitialized = false;

		public BusinessBase(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
			if (!isAutoMapperInitialized)
			{
				Mapper.Initialize(a => a.AddProfile<AutoMapperDomainProfile>());
				isAutoMapperInitialized = true;
			}
		}
	}
}