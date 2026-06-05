// Copyright (C) 2015-2026 The Neo Project.
//
// CryptoLib.BN254.cs file belongs to the neo project and is free
// software distributed under the MIT software license, see the
// accompanying file LICENSE in the main directory of the
// repository or http://www.opensource.org/licenses/mit-license.php
// for more details.
//
// Redistribution and use in source and binary forms with or without
// modifications are permitted.

#pragma warning disable CS0626

namespace Neo.SmartContract.Framework.Native
{
    public static partial class CryptoLib
    {
        /// <summary>
        /// Serializes a BN254 (alt_bn128) InteropInterface to a byte array: a G1 point to 64 bytes,
        /// a G2 point to 128 bytes, or a Gt (target-group) element to 384 bytes, all big-endian.
        /// No CallFlags requirement.
        /// <para>
        /// The execution will fail if:
        ///  1. the 'data' is null.
        ///  2. the 'data' is not a valid BN254 InteropInterface.
        /// </para>
        /// </summary>
        public static extern byte[] Bn254Serialize(object data);

        /// <summary>
        /// Deserializes a byte array into a BN254 (alt_bn128) InteropInterface: 64 bytes to a G1 point,
        /// 128 bytes to a G2 point, or 384 bytes to a Gt (target-group) element. Coordinates use the
        /// EIP-196/EIP-197 big-endian encoding and must be canonical residues below the field modulus;
        /// a G2 point must lie on the twist and inside the prime-order subgroup.
        /// No CallFlags requirement.
        /// <para>
        /// The execution will fail if:
        ///  1. the 'data' is null.
        ///  2. the 'data' length is not 64, 128, or 384 bytes.
        ///  3. the 'data' does not decode to a valid BN254 point or target-group element.
        /// </para>
        /// </summary>
        public static extern object Bn254Deserialize(byte[] data);

        /// <summary>
        /// Checks if two BN254 (alt_bn128) InteropInterface are equal.
        /// No CallFlags requirement.
        /// <para>
        /// The execution will fail if:
        ///  1. the 'x' or 'y' is null.
        ///  2. the 'x' or 'y' is not a valid BN254 InteropInterface.
        ///  3. the 'x' and 'y' are not the same type.
        /// </para>
        /// </summary>
        public static extern bool Bn254Equal(object x, object y);

        /// <summary>
        /// Adds two BN254 (alt_bn128) InteropInterface.
        /// No CallFlags requirement.
        /// <para>
        /// If 'x' is a G1 point, 'y' must be a G1 point and the result is their elliptic-curve sum;
        /// If 'x' is a Gt element, 'y' must be a Gt element and the result is their target-group product
        /// (field multiplication), which is how several pairings are composed before a single check.
        /// </para>
        /// <para>
        /// The execution will fail if:
        ///  1. the 'x' or 'y' is null.
        ///  2. the 'x' or 'y' is not a valid BN254 InteropInterface.
        ///  3. the type of 'y' mismatch with 'x'.
        /// </para>
        /// </summary>
        public static extern object Bn254Add(object x, object y);

        /// <summary>
        /// Multiplies a BN254 (alt_bn128) G1 point by a scalar.
        /// No CallFlags requirement.
        /// The 'scalar' must be a 32-byte big-endian value; it is reduced modulo the curve order.
        /// <para>
        /// The execution will fail if:
        ///  1. the 'x' is null.
        ///  2. the 'x' is not a valid BN254 G1 InteropInterface.
        ///  3. the 'scalar' is null.
        /// </para>
        /// </summary>
        public static extern object Bn254Mul(object x, byte[] scalar);

        /// <summary>
        /// Performs the optimal-ate pairing on a BN254 (alt_bn128) G1 point and G2 point, returning the
        /// resulting Gt (target-group) InteropInterface. Compose several pairing results with
        /// <see cref="Bn254Add"/> and compare with <see cref="Bn254Equal"/> to build a Groth16 check.
        /// No CallFlags requirement.
        /// <para>
        /// The execution will fail if:
        ///  1. the 'g1' or 'g2' is null.
        ///  2. the 'g1' is not a valid BN254 G1 InteropInterface;
        ///  3. the 'g2' is not a valid BN254 G2 InteropInterface.
        /// </para>
        /// </summary>
        public static extern object Bn254Pairing(object g1, object g2);
    }
}
