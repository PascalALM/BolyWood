
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Composants
{
    [DataContract]
    public struct STC_MSG
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nom { get; set; }

        [DataMember]
        public string DateCreation { get; set; }
        [DataMember]
        public string DateEdition { get; set; }
    }
}
