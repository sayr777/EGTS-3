﻿using Egts.Processing;
using System;

namespace Egts.Data.ServiceLayer
{
    public class ServiceDataSubrecord : IGetByteArray
    {
        /// <summary>SRT (Subrecord Type)</summary>
        public SubrecordType Type { get; set; }
        /// <summary>RL (Record Length)</summary>
        public ushort Length { get; set; }
        /// <summary>SRD (Subrecord Data)</summary>
        public SubrecordData Data { get; set; }


        public byte[] GetBytes()
        {
            if (!(Data is IGetByteArray))
                throw new NotSupportedException("SRT not implemet IGetByteArray");

            byte[] srData = Data.GetBytes();
            byte[] result = new byte[3 + srData.Length];

            result[0] = (byte)Type;
            BitConverter.GetBytes(Length).CopyTo(result, 1);
            srData.CopyTo(result, 3);

            return result;
        }
    }
}
