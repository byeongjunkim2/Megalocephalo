/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID SFX_MENUCANCEL = 1288124910U;
        static const AkUniqueID SFX_MENUCONFIRM = 54691296U;
        static const AkUniqueID SFX_MENUSELECT = 76764264U;
        static const AkUniqueID SFX_PLAYERCHARGE = 2870271946U;
        static const AkUniqueID SFX_PLAYERCHARGEEND = 1847534809U;
        static const AkUniqueID SFX_PLAYERSHOOT = 1882098847U;
        static const AkUniqueID STOPALL = 3086540886U;
        static const AkUniqueID TESTMUSIC = 1324413170U;
        static const AkUniqueID TESTSFX = 1650626098U;
        static const AkUniqueID UTL_SETSTATEPAUSED = 2434673480U;
        static const AkUniqueID UTL_SETSTATEUNPAUSED = 924590925U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace GAME_PAUSED
        {
            static const AkUniqueID GROUP = 3367563548U;

            namespace STATE
            {
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID PAUSED = 319258907U;
                static const AkUniqueID UNPAUSED = 1365518790U;
            } // namespace STATE
        } // namespace GAME_PAUSED

    } // namespace STATES

    namespace SWITCHES
    {
        namespace MUSIC_STATES
        {
            static const AkUniqueID GROUP = 1690668539U;

            namespace SWITCH
            {
            } // namespace SWITCH
        } // namespace MUSIC_STATES

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID PLAYERHEALTH = 151362964U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAINBANK = 2880737896U;
        static const AkUniqueID TESTSOUNDBANK = 1831431028U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SFX = 393239870U;
    } // namespace BUSSES

    namespace AUX_BUSSES
    {
        static const AkUniqueID REVERB = 348963605U;
    } // namespace AUX_BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
