
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Composants
{
    [DataContract]
    public struct STC_MSG
    {
        //
        [DataMember]
        public string AppName;
        [DataMember]
        public string AppVrs;

        //
        [DataMember]
        public string OpName;
        [DataMember]
        public bool OpStatut;
        [DataMember]
        public string MsgInfo;


        [DataMember]
        public object[] Data;


        //[DataMember]
        //public int BC_Id { get; set; }

        //[DataMember]
        //public string BC_Nom { get; set; }

        //[DataMember]
        //public List<Piece> BC_pieces { get; set; }

        //[DataMember]
        //public DateTime BC_Date_crea { get; set; }

        //[DataMember]
        //public DateTime BC_Date_prev { get; set; }


    }
}
