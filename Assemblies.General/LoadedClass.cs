using System;

namespace Assemblies.General
{
	public interface ILoaded
	{
		bool Loaded { get; }
	}

	public class LoadedClass : ILoaded
	{
		protected bool m_fLoaded = false;

		public LoadedClass()
		{
		}

		public bool Loaded
		{
			get
			{
				return m_fLoaded;
			}
		}
	}
}
