using System;
using BearLib;

namespace ReaperRL
{
    enum Action
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        UP_RIGHT,
        UP_LEFT,
        DOWN_RIGHT,
        DOWN_LEFT,
        UP_STAIRS,
        DOWN_STAIRS,
        GRAB,
        INVENTORY,
        WAIT,
        ENTER,
        EXIT,
        INTERACT,
        NULL,
    }

    //Note that this is a placeholder. And while the interface will stay the same
    //Eventually this needs to import from a file.
    static class Keybinds
    {
        static public Action ReturnAction(int key)
        {
            switch (key)
            {
                //Movement NumPAD
                case Terminal.TK_KP_8:
                    return Action.UP;
                case Terminal.TK_KP_2:
                    return Action.DOWN;
                case Terminal.TK_KP_4:
                    return Action.LEFT;
                case Terminal.TK_KP_6:
                    return Action.RIGHT;
                case Terminal.TK_KP_7:
                    return Action.UP_LEFT;
                case Terminal.TK_KP_9:
                    return Action.UP_RIGHT;
                case Terminal.TK_KP_1:
                    return Action.DOWN_LEFT;
                case Terminal.TK_KP_3:
                    return Action.DOWN_RIGHT;

                //Movement VI
                case Terminal.TK_K:
                    return Action.UP;
                case Terminal.TK_J:
                    return Action.DOWN;
                case Terminal.TK_H:
                    return Action.LEFT;
                case Terminal.TK_L:
                    return Action.RIGHT;
                case Terminal.TK_Y:
                    return Action.UP_LEFT;
                case Terminal.TK_U:
                    return Action.UP_RIGHT;
                case Terminal.TK_B:
                    return Action.DOWN_LEFT;
                case Terminal.TK_N:
                    return Action.DOWN_RIGHT;
                

                //Arrow Keys
                case Terminal.TK_UP:
                    return Action.UP;
                case Terminal.TK_DOWN:
                    return Action.DOWN;
                case Terminal.TK_LEFT:
                    return Action.LEFT;
                case Terminal.TK_RIGHT:
                    return Action.RIGHT;


                //Standard Actions
                case Terminal.TK_COMMA:
                    if (Terminal.Check(Terminal.TK_SHIFT)) { return Action.UP_STAIRS; }
                    return Action.GRAB;
                case Terminal.TK_G:
                    return Action.GRAB;
                case Terminal.TK_PERIOD:
                    if (Terminal.Check(Terminal.TK_SHIFT)) { return Action.DOWN_STAIRS; }
                    return Action.WAIT;
                case Terminal.TK_KP_5:
                    return Action.WAIT;
                case Terminal.TK_I:
                    return Action.INVENTORY;
                case Terminal.TK_SPACE:
                    return Action.INTERACT;

                //Selection
                case Terminal.TK_ENTER:
                    return Action.ENTER;
                case Terminal.TK_KP_ENTER:
                    return Action.ENTER;

                //Escape
                case Terminal.TK_ESCAPE:
                    return Action.EXIT;

                //Not a recognized key
                default:
                    return Action.NULL;
            }
        }
    }
}
