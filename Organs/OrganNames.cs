using System;
using System.Collections.Generic;
using System.Text;

namespace Physiology.Organs
{
    /// <summary>
    /// Defines major human organ types.
    /// </summary>
    public enum OrganNames
    {
        /// <summary>
        /// Brain – consciousness, motor ability, memory.
        /// </summary>
        Brain,

        /// <summary>
        /// Spinal cord – nerve signal transmission.
        /// </summary>
        Spine,

        /// <summary>
        /// Eye – vision, aiming, resource spotting.
        /// </summary>
        Eye,

        /// <summary>
        /// Ear – hearing, warning range.
        /// </summary>
        Ear,

        // ========== Circulatory & respiratory ==========
        /// <summary>
        /// Heart – blood circulation, bleeding out speed.
        /// </summary>
        Heart,

        /// <summary>
        /// Lung – breathing efficiency, stamina, infection risk (e.g., pneumonia).
        /// </summary>
        Lung,

        // ========== Digestive & metabolic ==========
        /// <summary>
        /// Liver – detoxification, metabolic rate, directly affects poison clearance.
        /// </summary>
        Liver,

        /// <summary>
        /// Kidney – blood filtration, water balance, toxin excretion.
        /// </summary>
        Kidney,

        /// <summary>
        /// Stomach – digestion, vomiting (e.g., after ingesting poison).
        /// </summary>
        Stomach,

        /// <summary>
        /// Intestine – nutrient absorption, diarrhea/dehydration.
        /// </summary>
        Intestine,

        /// <summary>
        /// Pancreas – blood sugar regulation, affected by extreme hunger.
        /// </summary>
        Pancreas,

        // ========== Immune & blood reserve ==========
        /// <summary>
        /// Spleen – immune function, blood storage; rupture causes internal bleeding.
        /// </summary>
        Spleen,

        // ========== Body barrier ==========
        /// <summary>
        /// Skin – physical protection, body temperature regulation, infection entry.
        /// </summary>
        Skin,

        // ========== Movement (these require body part tagging) ==========
        /// <summary>
        /// Bone – structural support and protection.
        /// </summary>
        Bone,

        /// <summary>
        /// Muscle – movement and strength.
        /// </summary>
        Muscle,

        /// <summary>
        /// Blood vessel – transport of blood.
        /// </summary>
        BloodVessel,

        /// <summary>
        /// Bone marrow – hematopoiesis; may be affected by certain toxins.
        /// </summary>
        BoneMarrow,
    }
}