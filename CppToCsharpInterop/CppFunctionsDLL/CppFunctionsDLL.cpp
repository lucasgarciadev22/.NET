// CppFunctionsDLL.cpp : Define as funções exportadas para a DLL.
//

#include <stdio.h>
#include "pch.h"
#include "framework.h"
#include "CppFunctionsDLL.h"

extern "C"
{
	// Este é o construtor de uma classe que foi exportada.
	CCppFunctionsDLL::CCppFunctionsDLL()
	{
		return;
	}

	// Isto é um exemplo de uma variável exportada
	CPPFUNCTIONSDLL_API int nCppFunctionsDLL = 0;

	// Isto é um exemplo de uma função exportada.

	CPPFUNCTIONSDLL_API int Add(int firstNum, int secondNum)
	{
		return firstNum + secondNum;
	}

	CPPFUNCTIONSDLL_API int Sub(int firstNum, int secondNum)
	{
		return firstNum - secondNum;
	}
}




