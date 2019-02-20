using System;

namespace labs4_6
{
    partial class Port
    {
        static Ship[] shipsArr;
        int maxIndex;

        public Ship this[int index]
        {
            get
            {
                if (index > maxIndex)
                {
                    throw new PortException("Превышен максимальный индекс массива кораблей", index, maxIndex);
                }
                return shipsArr[index];
            }
            set
            {
                if (index > maxIndex)
                    throw new PortException("Элемента с таким индексом не существует", index, maxIndex);
                else
                    shipsArr[index] = value;
            }
        }
    }
}
