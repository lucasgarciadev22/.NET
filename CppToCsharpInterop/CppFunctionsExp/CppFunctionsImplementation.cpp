#include <stdio.h>

extern "C"
{
#define Functions _declspec(dllexport)

	Functions int Add(int firstNum, int secondNum)
	{
		printf("Sum operation...");
		return firstNum + secondNum;
	}

	Functions int Sub(int firstNum, int secondNum)
	{
		printf("Subtract operation...");

		return firstNum - secondNum;
	}
}