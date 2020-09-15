﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.FileTypeSupport.Framework.Core.Utilities.BilingualApi;
using Sdl.FileTypeSupport.Framework.Core.Utilities.NativeApi;
using Sdl.FileTypeSupport.Framework.Formatting;
using Sdl.FileTypeSupport.Framework.NativeApi;

namespace Sdl.Community.Transcreate.FileTypeSupport.SDLXLIFF
{
	public class SegmentBuilder
	{
		private readonly IDocumentItemFactory _factory;
		private readonly IPropertiesFactory _propertiesFactory;
		private readonly IFormattingItemFactory _formattingFactory;

		public SegmentBuilder()
		{
			_factory = DefaultDocumentItemFactory.CreateInstance();
			_propertiesFactory = DefaultPropertiesFactory.CreateInstance();
			_formattingFactory = _propertiesFactory.FormattingItemFactory;
		}

		public List<string> ExistingTagIds { get; set; }

		public ITranslationOrigin CreateTranslationOrigin()
		{
			return _factory.CreateTranslationOrigin();
		}

		public IAbstractMarkupData CreatePlaceholder(string tagId, string tagContent)
		{
			// Dev Notes: the tagContent is switched with the Display text to align with how the tags are 
			// recreated by the XLIFF 1.2 parser from the framework

			var textProperties = _propertiesFactory.CreatePlaceholderTagProperties("<ph id=\"" + tagId + "\"/>");
			textProperties.DisplayText = tagContent;
			textProperties.SetMetaData("localName", "ph");
			textProperties.SetMetaData("displayText", tagContent);
			textProperties.SetMetaData("attribute:id", tagId);

			if (ExistingTagIds.Contains(textProperties.TagId.Id))
			{
				textProperties.TagId = !ExistingTagIds.Contains(tagId)
					? new TagId(tagId)
					: new TagId(GetUniqueTagPairId());
			}

			if (!ExistingTagIds.Contains(textProperties.TagId.Id))
			{
				ExistingTagIds.Add(textProperties.TagId.Id);
			}

			return _factory.CreatePlaceholderTag(textProperties);
		}

		public IAbstractMarkupData Text(string text)
		{
			var textProperties = _propertiesFactory.CreateTextProperties(text);
			return _factory.CreateText(textProperties);
		}

		public ISegmentPairProperties CreateSegmentPairProperties()
		{
			var properties = _factory.CreateSegmentPairProperties();
			properties.TranslationOrigin = CreateTranslationOrigin();
			return properties;
		}

		public IComment CreateComment(string text, string author, Severity severity, DateTime dateTime, string version)
		{
			var comment = _propertiesFactory.CreateComment(text, author, severity);
			comment.Date = dateTime;
			comment.Version = version;
			return comment;
		}

		public IAbstractMarkupData CreateCommentContainer(string text, string author, Severity severity, DateTime dateTime, string version)
		{
			var comment = _propertiesFactory.CreateComment(text, author, severity);
			comment.Date = dateTime;
			comment.Version = version;

			var commentProperties = _propertiesFactory.CreateCommentProperties();
			commentProperties.Add(comment);
			var commentMarker = _factory.CreateCommentMarker(commentProperties);

			return commentMarker;
		}

		public IAbstractMarkupData CreateTagPair(string tagId, string tagContent)
		{
			var tagName = GetStartTagName(tagContent, out var refId);

			// Dev Notes: the tagContent is switched with the Display text to align with how the tags are 
			// recreated by the XLIFF 1.2 parser from the framework

			var startTagProperties = _propertiesFactory.CreateStartTagProperties("<bpt id=\"" + tagId + "\">");
			startTagProperties.DisplayText = tagContent;
			startTagProperties.SetMetaData("localName", "bpt");
			startTagProperties.SetMetaData("displayText", tagContent);
			startTagProperties.SetMetaData("attribute:id", tagId);

			if (ExistingTagIds.Contains(startTagProperties.TagId.Id))
			{
				startTagProperties.TagId = !ExistingTagIds.Contains(tagId)
					? new TagId(tagId)
					: new TagId(GetUniqueTagPairId());
			}

			if (!ExistingTagIds.Contains(startTagProperties.TagId.Id))
			{
				ExistingTagIds.Add(startTagProperties.TagId.Id);
			}

			var endTagProperties = _propertiesFactory.CreateEndTagProperties("<ept id=\"" + tagId + "\">");
			endTagProperties.DisplayText = "</" + tagName + ">";
			endTagProperties.SetMetaData("localName", "ept");
			endTagProperties.SetMetaData("displayText", "</" + tagName + ">");
			endTagProperties.SetMetaData("attribute:id", tagId);


			//TODO formatting example
			//var xItem = _formattingFactory.CreateFormattingItem("italic", "True");
			//x.Formatting = _formattingFactory.CreateFormatting();
			//x.Formatting.Add(xItem);

			var tagPair = _factory.CreateTagPair(startTagProperties, endTagProperties);

			return tagPair;
		}

		private string GetUniqueTagPairId()
		{
			var id = 1;
			while (ExistingTagIds.Contains(id.ToString()))
			{
				id++;
			}

			return id.ToString();
		}

		public IAbstractMarkupData CreateLockedContent()
		{
			var lockedContentProperties = _propertiesFactory.CreateLockedContentProperties(LockTypeFlags.Manual);
			var lockedContent = _factory.CreateLockedContent(lockedContentProperties);
			return lockedContent;
		}


		public string GetStartTagName(string text, out string refId)
		{
			var tagName = string.Empty;
			refId = string.Empty;
			var regexTagName = new Regex(@"\<(?<name>[^\s""\>]*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
			var regexAttribute = new Regex(@"\s+(?<name>[^\s""]+)\=""(?<value>[^""]*)""", RegexOptions.Singleline | RegexOptions.IgnoreCase);

			var m = regexTagName.Match(text);
			if (m.Success)
			{
				tagName = m.Groups["name"].Value;
			}

			var mc = regexAttribute.Matches(text);
			if (mc.Count > 0)
			{
				foreach (Match match in mc)
				{
					var attValue = match.Groups["value"].Value;
					var attName = match.Groups["name"].Value;

					if (string.Compare(attName, "id", StringComparison.OrdinalIgnoreCase) == 0)
					{
						refId = attValue;
					}
				}
			}

			return tagName;
		}

		public string GetEndTagName(string text)
		{
			var tagName = string.Empty;

			var regexTagName = new Regex(@"\<\s*\/\s*(?<name>[^\s\>]*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);

			var m = regexTagName.Match(text);
			if (m.Success)
			{
				tagName = m.Groups["name"].Value;
			}

			return tagName;
		}

		public string GetEmptyTagName(string text)
		{
			var tagName = string.Empty;

			var regexTagName = new Regex(@"\<\s*(?<name>[^\s\>\/]*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);

			var m = regexTagName.Match(text);
			if (m.Success)
			{
				tagName = m.Groups["name"].Value;
			}

			return tagName;
		}
	}
}
