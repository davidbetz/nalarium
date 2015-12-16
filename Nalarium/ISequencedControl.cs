#region Copyright

//+ Copyright � David Betz 2007-2015

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