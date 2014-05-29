#include "main.h"
#include <math.h>

int DLL_EXPORT iloczyn(int a, int b)
{
    return a * b;
}

BOOL WINAPI DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved)
{
    return TRUE; // succesful
}
