#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright � Jampad Technology, Inc. 2007-2013

#endregion

namespace Nalarium
{
    public interface ISequencedControl
    {
        //- MoveToPreviousView -//
        void MoveToPreviousView();

        //- MoveToNextView -//
        void MoveToNextView();

        //- MoveToFirstView -//
        void MoveToFirstView();

        //- MoveToLastView -//
        void MoveToLastView();
    }
}