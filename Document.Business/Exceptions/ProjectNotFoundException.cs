using System;

namespace LS.Document.Business.Core.Exceptions
{
    public class ProjectNotFoundException : BusinessException
    {
        public ProjectNotFoundException()
            : base("Unable to find project with given ID.")
        {
        }
    }
}