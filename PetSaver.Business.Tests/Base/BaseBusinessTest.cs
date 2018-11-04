using PetSaver.Repository;

namespace PetSaver.Business.Tests.Base
{
    public class BaseBusinessTest
    {
        public BaseBusinessTest()
        {
            RegisterMappings.Register();
        }
    }
}
