#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
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