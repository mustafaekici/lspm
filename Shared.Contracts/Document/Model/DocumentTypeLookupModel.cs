using Shared.Contracts.Base;

namespace Shared.Contracts.Document.Model
{
    public class DocumentTypeLookupModel : LookupModel<int, string>
    {
        public DocumentTypeLookupModel()
        {
        }

        public DocumentTypeLookupModel(int key, string value) : base(key, value)
        {
        }
    }

}