﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaQuestionEditor_WPF.Models.Validation.Rules
{
    public class MediaFileSizeRule : QuestionSetValidationRule
    {
        private const int MAX_FILE_SIZE = 500 * 1024;

        public override List<ValidationProblem> Validate(QuestionSet questionSet)
        {
            List<ValidationProblem> problems = new List<ValidationProblem>();
            foreach (Media media in questionSet.Media)
            {
                if (new FileInfo(media.FullPath).Length > MAX_FILE_SIZE)
                {
                    problems.Add(new ValidationProblem(ProblemSeverity.Error, $"The file size of {media.Name} ({media.FileName}) is too large! Max file size is 500KB.", media));
                }
            }
            return problems;
        }
    }
}
