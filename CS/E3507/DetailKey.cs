using System;
using System.Collections.Generic;
using System.Linq;

namespace E1271
{
    public class DetailKey {
        public DetailKey(int _masterRowHandle, int _relationIndex) {
            MasterRowHandle = _masterRowHandle;
            RelationIndex = _relationIndex;
        }
        public int MasterRowHandle { get;set; }
        public int RelationIndex { get;set; }
        public override int GetHashCode() {
            return MasterRowHandle.GetHashCode() ^ RelationIndex.GetHashCode();
        }
        public override bool Equals(object obj) {
            if (obj is DetailKey)
                return ((DetailKey)obj).MasterRowHandle == MasterRowHandle && ((DetailKey)obj).RelationIndex == RelationIndex;
            return base.Equals(obj);
        }
    }
}
