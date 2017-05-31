﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Converter_from_binary_to_csv
{
    public interface IConvertingBinaryToCSV: IReaderFromBinaryFiles,IWriteToCSV
    {
        new void fromBinaryFile();
        new void toCSV();
    }

}